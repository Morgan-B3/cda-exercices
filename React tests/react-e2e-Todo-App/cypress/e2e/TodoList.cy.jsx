describe("Todo-app E2E", () => {
    beforeEach(() => {
        cy.visit("http://localhost:5173/")
    })

    it("Le texte “Aucune tâche” s’affiche au départ",() => {
        cy.get('[data-id="empty-list"]').should('contain.text','Aucune tâche')
    })

    it("Lorsqu’on saisit une tâche (“Acheter du pain”) et qu’on clique sur “Ajouter”, elle s’affiche dans la liste",() => {
        cy.get('[data-id="text"]').type("Acheter du pain")
        cy.contains('button',/ajouter/i).click()
        cy.contains("li",/Acheter du pain/i)
    })

    it("Lorsqu’on clique sur “Supprimer”, la tâche est retirée de la liste et le message “Aucune tâche” réapparaît.",() => {
        cy.get('[data-id="text"]').type("Acheter du pain")
        cy.contains('button',/ajouter/i).click()
        cy.contains('button',/supprimer/i).click()
        cy.contains("li",/Acheter du pain/i).should('not.exist')
        cy.get('[data-id="empty-list"]').should('contain.text','Aucune tâche')
    })
})