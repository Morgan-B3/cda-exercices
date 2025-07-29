package com.example.jeeexo1;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;

@WebServlet(name = "bobServlet", value = "/bob")
public class BobServlet extends HttpServlet {
    @Override
    public void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.setAttribute("nom","Bob");
        req.setAttribute("color","bg-info");
        req.getRequestDispatcher("/user.jsp").forward(req,resp);
    }
}
