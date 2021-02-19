console.log("Loaded");

function confirmDelete(userId, confirm) {
    let deleteSpan = document.getElementById(`delete-${userId}`);
    let confirmDeleteSpan = document.getElementById(`confirm-delete-${userId}`);
    
    if(confirm) {
        deleteSpan.style.display = "none";
        confirmDeleteSpan.style.display = "inline";
    } else {
        deleteSpan.style.display = "inline";
        confirmDeleteSpan.style.display = "none";        
    }
    
}