export function filterPairs(values){
    if(values.length ===0){
        throw new Error("Il doit y avoir au moins une valeur")
    }

    return values.filter(e => e % 2 === 0 && typeof e === "number")
}