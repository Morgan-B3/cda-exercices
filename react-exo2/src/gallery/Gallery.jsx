import React from "react";
import { IMAGES, CATEGORIES } from "./data.js";
import Card from "./Card.jsx";
import { useState } from "react";
import { useEffect } from "react";
import Category from "./Category.jsx";

function Gallery() {
  const [selectedCategories, setSelectedCategories] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    setTimeout(() => setLoading(false), 3000);
  }, []);

  function select(category) {
    if (selectedCategories.includes(category)) {
      setSelectedCategories((s) =>
        s.filter((categoryS) => category != categoryS)
      );
    } else {
      setSelectedCategories((s) => [...s, category]);
    }
  }

  const imagesList = IMAGES.filter((image) => {
    if (
      selectedCategories.length === 0 ||
      selectedCategories.includes("toutes") ||
      image.categories.filter((category) =>
        selectedCategories.includes(category)
      ).length > 0
    ) {
      return image;
    }
  }).map((image) => {
    return <Card key={image.id} image={image} loading={loading}></Card>;
  });

  const categoriesList = CATEGORIES.map((category) => {
    return (
      <Category
        key={category}
        category={category}
        selectedCategories={selectedCategories}
        action={() => select(category)}
      ></Category>
    );
  });

  return (
    <>
      <h1>Galerie d'images</h1>
      <div className="flex">
        <p>Filtres :</p>
        <div className="flex">{categoriesList}</div>
      </div>
        {imagesList.length > 0 ? (
            <section className="grid">
                <>{imagesList}</>
            </section>
        ) : (
          <p>Aucune image disponible</p>
        )}
    </>
  );
}

export default Gallery;
