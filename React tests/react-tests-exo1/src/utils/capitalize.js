export function capitalize(str) {
    if(typeof str !== "string" || str === ""){
        throw new Error("L'entrée doit être une chaine de caractères valide")
    }
    return String(str).charAt(0).toUpperCase() + String(str).slice(1);
}