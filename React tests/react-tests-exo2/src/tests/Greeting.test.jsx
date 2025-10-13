import { render , screen} from "@testing-library/react";
import { describe, expect } from "vitest";
import userEvent from '@testing-library/user-event'
import Greeting from "../components/Greeting.jsx";

describe("Counter", () => {
    it("Affichage du texte en prop", () => {
        // rendu du composant
        render(<Greeting name="React"/>)
        expect(screen.getByText(/bonjour, react !/i)).toBeInTheDocument()
    })

    it("Affichage du nom 'invité' par défaut", async () => {
        render(<Greeting />)
        expect(screen.getByText(/bonjour, invité !/i)).toBeInTheDocument()
    })

})