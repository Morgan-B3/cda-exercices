import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { CartProvider } from '../context/CartContext'
import { ShoppingList } from './ShoppingList'

function renderWithProvider(ui) {
  return render(<CartProvider>{ui}</CartProvider>)
}

describe("ShoppingList (integration parent/enfant + contexte)", () => {
  test('état initial et accessibilité', () => {
    renderWithProvider(<ShoppingList />)
    expect(screen.getByText(/Total : 0/i)).toBeInTheDocument();
    expect(screen.getByText(/Aucun article/i)).toBeInTheDocument();
    expect(screen.getByRole('button', {name: /Ajouter/i})).toBeDisabled();

  })
  
  test("ajout d'un article met a jour la liste et le total", async () => {
    renderWithProvider(<ShoppingList />)
    const input = screen.getByPlaceholderText(/Nouvel article/i);
    const button = screen.getByRole('button', {name: /Ajouter/i});
    
    await userEvent.type(input, "Lait");
    await userEvent.click(button);
    expect(screen.getByText(/Total : 1/i)).toBeInTheDocument();
    expect(screen.getByText(/Lait/i)).toBeInTheDocument();

  })

  test("ajouts multiples et toggle achete", async () => {
    renderWithProvider(<ShoppingList />)
    const input = screen.getByPlaceholderText(/Nouvel article/i);
    const button = screen.getByRole('button', {name: /Ajouter/i});
    
    await userEvent.type(input, "Lait");
    await userEvent.click(button);
    await userEvent.type(input, "Pain");
    await userEvent.click(button);
    expect(screen.getByText(/Total : 2/i)).toBeInTheDocument();
    expect(screen.getByText(/Lait/i)).toBeInTheDocument();
    expect(screen.getByText(/Pain/i)).toBeInTheDocument();
    const checkbox = screen.getAllByRole("checkbox")
    await userEvent.click(checkbox[0])
    expect(screen.getByText(/acheté/i)).toBeInTheDocument();

  })

  test("suppression d'un article", async () => {
    renderWithProvider(<ShoppingList />)
    const input = screen.getByPlaceholderText(/Nouvel article/i);
    const button = screen.getByRole('button', {name: /Ajouter/i});
    
    await userEvent.type(input, "Lait");
    await userEvent.click(button);
    await userEvent.type(input, "Pain");
    await userEvent.click(button);
    const buttons = screen.getAllByRole('button', {name: /Supprimer/i});
    await userEvent.click(buttons[0])
    expect(screen.getByText(/Total : 1/i)).toBeInTheDocument();
    expect(screen.queryByText(/Lait/i)).toBeNull();
    expect(screen.getByText(/Pain/i)).toBeInTheDocument();
  })
})