import React from "react";

function Category({ category, selectedCategories, action }) {
  return (
    <p
      className={
        selectedCategories.includes(category) ? "selected category" : "category"
      }
      onClick={() => action(category)}
    >
      {category}
    </p>
  );
}

export default Category;
