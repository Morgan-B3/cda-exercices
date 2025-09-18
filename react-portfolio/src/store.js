import { configureStore, createSlice } from "@reduxjs/toolkit";

// un slice est un morceau de notre state global avec sa propre logique

const initialState = {
    items:[
        {
            id: 1,
            label: "Courses",
            amount: 15,
            date:"02-02-2025",
            category:"Alimentation"
        },
        {
            id: 2,
            label: "Cadeau",
            amount: 35,
            date:"01-05-2019",
            category:"Loisirs"
        },
    ]
}

const expenseSlice = createSlice({
    name: "expenses", // nom de notre slice
    initialState, // valeur initiale de notre state
    reducers : {  // fonctions qui peuvent agir sur ce morceau de state en reponse a des actions
        addItem: (state,action) => {state.items.push(action.payload)},
        removeItem: (state,action) => {state.items = state.items.filter(item => item.id !== action.payload)}
    }
})


// un slice = state + reducers + actions

export const {addItem,removeItem} = expenseSlice.actions;

// le store
// state global compose de tous nos slices

export const store = configureStore({
    reducer:{ 
        expenses: expenseSlice.reducer,
    }
})
