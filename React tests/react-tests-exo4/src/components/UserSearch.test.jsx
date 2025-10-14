import { render, screen, waitFor } from "@testing-library/react";
import { describe, expect } from "vitest";
import { UserSearch } from "./UserSearch.jsx";
import userEvent from '@testing-library/user-event'



describe("UserSearch HTTP simulé", () => {
    afterEach(() => {
        vi.resetAllMocks()
    })

    test("Avant toute action : seul le champ et le bouton sont visibles", () => {
        render(<UserSearch />)
        expect(screen.getByPlaceholderText(/Saisissez un nom.../i)).toBeInTheDocument()
        expect(screen.queryByRole('button', {name: /rechercher/i})).toBeInTheDocument()
        expect(screen.queryByRole("p")).toBeNull()
    })

    test("Après clic sur “Rechercher”, “Chargement…” s’affiche immédiatement et le message disparaît à la fin de la requête",async () => {
        render(<UserSearch />)
        const input = screen.getByPlaceholderText(/Saisissez un nom.../i)
        const button = screen.queryByRole('button', {name: /rechercher/i})

        await userEvent.type(input, "toto")
        await userEvent.click(button)
        expect(screen.getByText(/Chargement.../i)).toBeInTheDocument()

        global.fetch = vi.fn().mockResolvedValue({
            ok: true,
            json: () => Promise.resolve({ name: "Toto"})
        })

        await waitFor(()=>{
            expect(screen.queryByText(/Chargement.../i)).not.toBeInTheDocument()
        }) 
    })

    test("Le nom de l’utilisateur s’affiche correctement",async () => {
        global.fetch = vi.fn().mockResolvedValue({
            ok: true,
            json: () => Promise.resolve({ name: "Toto"})
        })
        render(<UserSearch />)

        const input = screen.getByPlaceholderText(/Saisissez un nom.../i)
        const button = screen.queryByRole('button', {name: /rechercher/i})

        await userEvent.type(input, "toto")
        await userEvent.click(button)

        expect(screen.getByText("Utilisateur trouvé : Toto")).toBeInTheDocument()
    })

    test("Le message d’erreur “Utilisateur introuvable” s’affiche.", async () => {
        global.fetch = vi.fn().mockResolvedValue({
            ok: false,
        })
        render(<UserSearch />)

        const input = screen.getByPlaceholderText(/Saisissez un nom.../i)
        const button = screen.queryByRole('button', {name: /rechercher/i})

        await userEvent.type(input, "toto")
        await userEvent.click(button)

        expect(screen.getByText("Utilisateur introuvable")).toBeInTheDocument()
    })
})