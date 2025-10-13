package com.example.jeeexo2.controllers;

import com.example.jeeexo2.models.Person;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

@WebServlet(name = "personServlet", value = "/person")
public class PersonServlet extends HttpServlet {
    private List<Person> persons;

    @Override
    public void init() throws ServletException {
        persons = new ArrayList<>();
        persons.add(new Person("John", "Doe", 18));
        persons.add(new Person("Jane", "Doe", 35));
        persons.add(new Person("Bob", "Ross", 75));
    }

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.setAttribute("persons", persons);
        req.getRequestDispatcher("/person.jsp").forward(req, resp);
    }
}
