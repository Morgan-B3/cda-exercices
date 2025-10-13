import { describe, expect, it } from "vitest";
import { filterPairs } from "./filterPairs.js";


describe('moyenne()', () => {
    // cas standard
    it("retourne les nombres pairs du tableau", () => {
        expect(filterPairs([1, 2, 3, 4, 5])).toStrictEqual([2, 4])
    })
    it("retourne les nombres pairs du tableau même si pas que des nombres", () => {
        expect(filterPairs([10, 'a', 15, 20])).toStrictEqual([10, 20])
    })
    // erreur
    it("gestion de tableau vide", () => {
        expect(() => filterPairs([])).toThrow("Il doit y avoir au moins une valeur")
    })
})