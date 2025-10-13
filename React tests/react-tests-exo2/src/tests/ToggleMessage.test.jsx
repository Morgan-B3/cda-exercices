import { render , screen} from "@testing-library/react";
import { describe, expect } from "vitest";
import userEvent from '@testing-library/user-event'
import ToggleMessage from "../components/ToggleMessage.jsx";

describe("Counter", () => {
    it("Au départ, le message n’est pas affiché", () => {
        // rendu du composant
        render(<ToggleMessage />)
        expect(screen.queryByText(/Coucou !/i)).toBeNull()
    })

    it("Après un clic, le message apparaît", async () => {
        render(<ToggleMessage />)
        const user = userEvent.setup()
        const button = screen.getByRole("button",{ name: /afficher/i})
        await user.click(button)
        expect(screen.getByText(/Coucou !/i)).toBeInTheDocument()
    })
    it("Après un second clic, le message disparaît", async () => {
        render(<ToggleMessage />)
        const user = userEvent.setup()
        const button = screen.getByRole("button",{ name: /afficher/i})
        await user.click(button)
        const button2 = screen.getByRole("button",{ name: /cacher/i})
        await user.click(button2)
        expect(screen.queryByText(/Coucou !/i)).toBeNull()
    })

})