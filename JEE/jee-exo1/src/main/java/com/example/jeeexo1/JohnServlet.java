package com.example.jeeexo1;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;

@WebServlet(name = "johnServlet", value = "/john")
public class JohnServlet extends HttpServlet {
    @Override
    public void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.setAttribute("nom","John");
        req.setAttribute("color","bg-warning");
        req.getRequestDispatcher("/user.jsp").forward(req,resp);
    }
}
