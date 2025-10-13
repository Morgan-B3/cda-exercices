import React, { useEffect, useState } from "react";
import useCopy from "../../hooks/citation/useCopy.js";
import { fetchPost } from "../../api/citation/citationApi.js";
function Citation() {
  const [citation, setCitation] = useState(null);
  const [error, setError] = useState("");

  const { copy } = useCopy();

  function getCitation() {
    fetchPost()
      .then((data) => {
        setCitation(data);
      })
      .catch((e) => setError(e.message));
  }

  useEffect(() => {
    getCitation();
  }, []);

  if (error) return <p>Erreur : {error}</p>;
  if (!citation) return <p>Chargement...</p>;

  return (
    <div>
      <h2>"{citation.quote}"</h2>
      <p>{citation.author}</p>
      <div className="flex">
        <button onClick={getCitation}>Autre</button>
        <button onClick={() => copy(citation.quote)}>Copier</button>
      </div>
    </div>
  );
}

export default Citation;
