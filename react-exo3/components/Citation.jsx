import React, { useEffect, useState } from 'react'
import { fetchPost } from './citationApi.js';
import useCopy from './useCopy.js';
function Citation() {

    const [citation,setCitation] = useState(null);
    const [error, setError] = useState("");

    const {copy} = useCopy();

    useEffect(() => {
        fetchPost()
            .then(data => {
                setCitation(data)
                
            })
            .catch(e => setError(e.message))
    },[])

    if(error) return <p>Erreur : {error}</p>
    if(!citation) return <p>Chargement...</p>

  return (
    <div>
        <h2>"{citation.quote}"</h2>
        <p>{citation.author}</p>
        <button onClick={()=>copy(citation.quote)}>Copier</button>
    </div>
  )
}

export default Citation