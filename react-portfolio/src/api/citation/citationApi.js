export const API_BASE = "https://dummyjson.com/quotes/random";

export async function fetchPost() {
    const res = await fetch(`${API_BASE}`);
    if(!res.ok) throw new Error(`HTTP ${res.status}`);
    return res.json();
}