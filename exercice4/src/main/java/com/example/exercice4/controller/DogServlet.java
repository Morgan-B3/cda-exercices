package com.example.exercice4.controller;

import com.example.exercice4.model.Dog;
import com.example.exercice4.service.DogService;
import com.example.exercice4.service.IDogService;
import com.example.exercice4.util.HibernateSession;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.time.LocalDate;

@WebServlet(name = "dogServlet", value = {"/dog/*"})
public class DogServlet extends HttpServlet {
    private IDogService dogService;


    @Override
    public void init() throws ServletException {
        dogService = new DogService(HibernateSession.getSessionFactory());
    }

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String pathInfo = (req.getPathInfo()!=null && !req.getPathInfo().isEmpty()) ? req.getPathInfo() : "";
        System.out.println("pathInfo: " + pathInfo);
        if (pathInfo!=null && !pathInfo.isEmpty()) {
            if (pathInfo.equals("/all")) {
                req.setAttribute("dogList", dogService.getAll());
                req.getRequestDispatcher("/WEB-INF/dog/add.jsp").forward(req, resp);
            } else if (pathInfo.startsWith("/show")) {
                Dog dog = dogService.getById(Integer.parseInt(req.getParameter("id")));
                if (dog != null) {
                    req.setAttribute("dog", dog);
                    req.getRequestDispatcher("/WEB-INF/dog/show.jsp").forward(req, resp);
                } else {
                    req.getRequestDispatcher("/WEB-INF/404.jsp").forward(req, resp);
                }
                System.out.println("id : "+Integer.parseInt(req.getParameter("id")));
                System.out.println("chien : "+dog);
            } else {
                req.getRequestDispatcher("/WEB-INF/404.jsp").forward(req, resp);
            }

        }
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        // recuperer les infos du formulaire pour ajouter un chien
        String name = req.getParameter("name");
        String breed = req.getParameter("breed");

        LocalDate dateOfBirth = LocalDate.parse(req.getParameter("dateOfBirth"));
        // Creation d'un chien
        Dog dog = new Dog(name, breed, dateOfBirth);
        // Ajout du chat a la liste
        dogService.addDog(dog);
        resp.sendRedirect(getServletContext().getContextPath()+"/dog");
    }
}
