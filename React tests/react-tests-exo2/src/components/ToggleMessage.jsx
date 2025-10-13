import React, { useState } from "react";

export default function ToggleMessage() {
  const [hidden, setHidden] = useState(true);

  const toggleHidden = ()=>{
    setHidden(e=>!e);
  }

  return (
    <div>
        {hidden?(
            ""
        ):(
            <p>Coucou !</p>
        )}

      <button onClick={() => toggleHidden()}>{hidden ? "Afficher":"Cacher"}</button>
    </div>
  );
}
