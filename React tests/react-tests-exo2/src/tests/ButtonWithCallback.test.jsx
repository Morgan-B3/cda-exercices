import { render , screen} from "@testing-library/react";
import { describe, expect, vi } from "vitest";
import userEvent from '@testing-library/user-event'
import ButtonWithCallback from "../components/ButtonWithCallback.jsx";

describe("Counter", () => {
    it("Le bouton appelle la fonction passée en prop.", async () => {
        const handleClick = vi.fn();

        render(<ButtonWithCallback onClick={handleClick} />)
        const user = userEvent.setup()
        const button = screen.getByRole("button",{ name: /Bouton/i})
        await user.click(button)
        expect(handleClick).toHaveBeenCalled();
    })
    it("Le bouton appelle plusieurs fois la fonction passée en prop.", async () => {
        const handleClick = vi.fn();

        render(<ButtonWithCallback onClick={handleClick} />)
        const user = userEvent.setup()
        const button = screen.getByRole("button",{ name: /Bouton/i})
        await user.click(button)
        await user.click(button)
        await user.click(button)
        expect(handleClick).toHaveBeenCalledTimes(3);
    })

})