import { describe, expect, it } from "vitest";
import { moyenne } from "./moyenne.js";


describe('moyenne()', () => {
    // cas standard
    it("retourne la moyenne des nombres du tableau", () => {
        expect(moyenne([10, 20, 30])).toBe(20)
    })
    it("retourne la moyenne d'un seul élément", () => {
        expect(moyenne([5])).toBe(5)
    })
    // erreur
    it("gestion de tableau vide", () => {
        expect(() => moyenne([])).toThrow("Il doit y avoir au moins une valeur")
    })
    // erreur
    it("leve une erreur si un des arguments n'est pas un nombre",() => {
        expect(() => moyenne([1,"b"])).toThrow("Toutes les valeurs doivent etre des nombres")
    })
})