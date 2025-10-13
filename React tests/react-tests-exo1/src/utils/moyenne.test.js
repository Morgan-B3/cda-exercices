import { describe, expect, it } from "vitest";
import { moyenne } from "./moyenne.js";


describe('moyenne()', () => {
    // cas standard
    it("retourne la moyenne des nombres du tableau", () => {
        expect(moyenne([1,2,3])).toBe(2)
    })
    // cas avec un nombre negatif
    it("gestion de tableau vide", () => {
        expect(() => moyenne([])).toThrow("Il doit y avoir au moins une valeur")
    })
    // cas d'erreur
    it("leve une erreur si un des arguments n'est pas un nombre",() => {
        expect(() => moyenne('a',"b")).toThrow("Toutes les valeurs doivent etre des nombres")
    })
})