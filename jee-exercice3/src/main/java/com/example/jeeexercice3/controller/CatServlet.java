package com.example.jeeexercice3.controller;

import com.example.jeeexercice3.model.Cat;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@WebServlet(name = "catServlet", value = "/cat")
public class CatServlet extends HttpServlet {
    private List<Cat> cats;

    @Override
    public void init() throws ServletException {
        cats = new ArrayList<>();
//        cats.add(new Cat("Garfield", "Roux", "Lasagnes", LocalDate.of( 1999 , 4 , 1 )));
//        cats.add(new Cat("Tom", "Gris", "Jerry", LocalDate.of( 2020 , 12 , 25 )));
//        cats.add(new Cat("Friend", "Inconnue", "???", LocalDate.of( 2025 , 6 , 30 )));
    }

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.setAttribute("cats", cats);
        req.getRequestDispatcher("/WEB-INF/cat/list.jsp").forward(req, resp);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        // Recuperation des donnees du formulaire
        String name = req.getParameter("name");
        String breed = req.getParameter("breed");
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd");
        LocalDate birthday = LocalDate.parse(req.getParameter("birthday"), formatter);
        String food = req.getParameter("food");
        System.out.println("name: " + name);
        System.out.println("breed: " + breed);
        System.out.println("food: " + food);
        System.out.println("birthday: " + birthday);

        cats.add(new Cat(name, breed, food, birthday));
        
        req.setAttribute("cats", cats);
        req.getRequestDispatcher("/WEB-INF/cat/list.jsp").forward(req, resp);
    }
}
