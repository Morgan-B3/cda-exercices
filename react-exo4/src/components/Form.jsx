import React, { useRef } from "react";
import { categories } from "../data/categories.js";
import { useDispatch } from "react-redux";
import { addItem } from "../store.js";
import { useState } from "react";

function Form() {
  const labelRef = useRef();
  const amountRef = useRef();
  const categoryRef = useRef();
  const dateRef = useRef();

  const [id, setId] = useState(3);

  const dispatch = useDispatch();

  const submitForm = (e) => {
    e.preventDefault();
    console.log("Libellé : " + labelRef.current.value);
    console.log("Montant : " + amountRef.current.value);
    console.log("Carégorie : " + categoryRef.current.value);
    console.log("Date : " + dateRef.current.value);

    dispatch(addItem({
        id,
        label:labelRef.current.value,
        date:dateRef.current.value,
        category:categoryRef.current.value,
        amount:Number(amountRef.current.value),
    }))
    console.log(id);
    
    setId(s=>s++)

    console.log(id);
    
  };

  let curr = new Date();
  curr.setDate(curr.getDate());
  let date = curr.toISOString().substring(0, 10);

  const categoriesList = categories.map((category) => {
    return (
      <option key={category} value={category}>
        {category}
      </option>
    );
  });

  return (
    <form onSubmit={submitForm}>
      <div className="flex flex-col">
        <label htmlFor="label">Libellé :</label>
        <input
          id="label"
          ref={labelRef}
          type="text"
          placeholder="Ex : Coiffeur"
          required
        />
      </div>
      <div className="flex flex-col">
        <label htmlFor="amount">Montant :</label>
        <div className="flex">
          <input
            id="amount"
            ref={amountRef}
            type="number"
            placeholder="Ex : 18"
            required
          />
          <p>€</p>
        </div>
      </div>
      <div className="flex flex-col">
        <label htmlFor="category">Catégorie :</label>
        <select id="categroy" name="category" ref={categoryRef} required>
          <option hidden value="">Choisissez une catégorie</option>
          {categoriesList}
        </select>
      </div>
      <div className="flex flex-col">
        <label htmlFor="date">Date :</label>
        <input
          id="date"
          ref={dateRef}
          type="date"
          defaultValue={date}
          required
        />
      </div>
      <button>valider</button>
    </form>
  );
}

export default Form;
