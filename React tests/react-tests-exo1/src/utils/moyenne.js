export function moyenne(values) {
    let sum = 0;
    for(let value of values){
        if(typeof value !== 'number'){
            throw new Error("Toutes les valeurs doivent etre des nombres")
        }
        sum += value;
    }

    return sum/values.length
}