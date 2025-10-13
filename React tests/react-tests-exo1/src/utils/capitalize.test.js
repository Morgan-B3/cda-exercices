import { describe, expect, it } from "vitest";
import { capitalize } from "./capitalize.js";


describe('moyenne()', () => {
    // cas standard
    it("retourne la première lettre en majuscule", () => {
        expect(capitalize("toto va à l'école")).toBe("Toto va à l'école")
    })
    // cas avec chaine vide
    it("gestion de chaine vide", () => {
        expect(() => capitalize("")).toThrow("L'entrée doit être une chaine de caractères valide")
    })
    // cas d'erreur
    it("si l'entrée n'est pas une chaine",() => {
        expect(() => capitalize(42)).toThrow("L'entrée doit être une chaine de caractères valide")
    })
})