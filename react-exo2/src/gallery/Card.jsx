import React from "react";
import { Skeleton } from "antd";

function Card({ image, loading }) {
  const categories = image.categories.map((category) => {
    return (
      <p key={category} className="category">
        {category}
      </p>
    );
  });
  return (
    <div className="gallery-card">
      {loading ? (
        <Skeleton loading={loading} active></Skeleton>
      ) : (
        <>
          <img className="img" src={image.url} />
          <div className="container">
            <h4>{image.title}</h4>
            <p className="author">Auteur: {image.author}</p>
            <div className="flex categories">{categories}</div>
          </div>
        </>
      )}
    </div>
  );
}

export default Card;
