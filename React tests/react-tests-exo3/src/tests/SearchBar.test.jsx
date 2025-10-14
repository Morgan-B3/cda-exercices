import { render , screen} from "@testing-library/react";
import { describe, expect, vi } from "vitest";
import userEvent from '@testing-library/user-event'
import SearchBar from "../components/SearchBar.jsx";

describe("Counter", () => {
    it("Saisie d’une requête puis clic sur le bouton rechercher", async () => {
        const handleForm = vi.fn()
        render(<SearchBar handleForm={handleForm} />)

        const searchInput = screen.getByPlaceholderText(/recherche/i)
        const submitButton = screen.getByRole('button', {name: /rechercher/i})

        await userEvent.type(searchInput, "   toto   tata")
        await userEvent.click(submitButton)
        expect(handleForm).toHaveBeenCalled();
    })

    it("Saisie d’une requête puis appui sur touche entrée", async () => {
        const handleForm = vi.fn()
        render(<SearchBar handleForm={handleForm} />)
        
        const searchInput = screen.getByPlaceholderText(/recherche/i)
        
        await userEvent.type(searchInput, "toto{enter}")
        expect(handleForm).toHaveBeenCalled();
    })

    it("Bouton désactivé si le champ est vide ou ne contient que des espaces", async () => {
        const handleForm = vi.fn()
        render(<SearchBar handleForm={handleForm} />)

        const searchInput = screen.getByPlaceholderText(/recherche/i)
        const submitButton = screen.getByRole('button', {name: /rechercher/i})

        await userEvent.type(searchInput, "   ")
        expect(submitButton).toBeDisabled();
    })
    
    it("Aucune recherche lancée si la requête est vide (après trim).", async () => {
        const handleForm = vi.fn()
        render(<SearchBar handleForm={handleForm} />)

        const searchInput = screen.getByPlaceholderText(/recherche/i)
        const submitButton = screen.getByRole('button', {name: /rechercher/i})

        await userEvent.type(searchInput, "   ")
        await userEvent.click(submitButton)
        expect(handleForm).not.toHaveBeenCalled();
    })

    it("Le focus clavier permet d’atteindre input puis bouton (tabulation testable).", async () => {
        const handleForm = vi.fn()
        render(<SearchBar handleForm={handleForm} />)

        const searchInput = screen.getByPlaceholderText(/recherche/i)

        await userEvent.type(searchInput, "toto{tab}{enter}")
        expect(handleForm).toHaveBeenCalled();
    })

})