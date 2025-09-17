import React from "react";

export default function useCopy() {
  const copy = async (text) => {
    try {
      await navigator.clipboard.writeText(text);
    } catch (e) {
      console.error("probleme lors de la copie");
    }
  };
  return {copy};
}
