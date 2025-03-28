// Mapeo de enums a valores
const priorityMap = {
    "0": "Baja",
    "1": "Media",
    "2": "Alta",
    "3": "Crítica"
};

const stateMap = {
    "0": "Abierto",
    "1": "Progreso",
    "2": "Resuelto",
    "3": "Cerrado"
};

const authorTypeMap = {
    "0": "Usuario",
    "1": "Técnico"
};

// Cargar comentarios y manejar visibilidad
function loadComments(incidentId) {
     const commentsContainer = $('#comments-' + incidentId);
     const button = $('#toggle-comments-btn-' + incidentId);

     if (commentsContainer.is(':visible')) {
         commentsContainer.hide();
         button.text('Ver Comentarios');
         return;
     }

     $.ajax({
         url: `/api/comment/${incidentId}`,
         type: 'GET',
         success: function (comments) {
             let html = '<ul class="list-group mt-2">';

             if (!comments || comments.length === 0) {
                 html += '<li class="list-group-item">No hay comentarios para este incidente.</li>';
             } else {
                 comments.forEach(c => {
                     let commentDate = new Date(c.createdAt).toLocaleString();
                     html += `
                            <li class="list-group-item">
                                <strong>${authorTypeMap[c.authorType] || c.authorType}</strong> 
                                <small class="text-muted">(${commentDate})</small>
                                <p>${c.content}</p>
                            </li>
                        `;
                 });
             }

             html += '</ul>';
             commentsContainer.html(html).show();
             button.text('Ocultar Comentarios');
         },
         error: function () {
             commentsContainer.html('<p>Error al cargar los comentarios.</p>').show();
             button.text('Ocultar Comentarios');
         }
     });
 }

// Agregar comentario
async function addComment(incidentId) {
    const inputField = document.getElementById(`comment-${incidentId}`);
    const comment = inputField.value.trim();

    if (comment.trim() === "") {
        alert("El comentario no puede estar vacío.");
        return;
    }
    await fetch(`/api/comment`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ "Content": comment, "IdIncident": incidentId, "AuthorType": authorType })
    });
    loadComments(incidentId);
    inputField.value = "";
}
