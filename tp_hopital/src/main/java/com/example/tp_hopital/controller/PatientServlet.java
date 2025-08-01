package com.example.tp_hopital.controller;

import com.example.tp_hopital.model.Patient;
import com.example.tp_hopital.service.IPatientService;
import com.example.tp_hopital.service.PatientService;
import com.example.tp_hopital.util.HibernateSession;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.MultipartConfig;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.Part;

import java.io.File;
import java.io.IOException;
import java.time.LocalDate;
import java.util.Date;
import java.util.Locale;

@WebServlet(name = "patientServlet", value = "/patients/*")
@MultipartConfig(maxFileSize =  1024 * 1024*10)
public class PatientServlet extends HttpServlet {
    private IPatientService patientService;

    @Override
    public void init() throws ServletException{
        patientService = new PatientService(HibernateSession.getSessionFactory());
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        doGet(req, resp);
    }

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp)throws ServletException, IOException{
        String action = req.getPathInfo().substring(1);
        switch (action){
            case "add":
                add(req, resp);
                break;
            case "list":
                showAllPatients(req, resp);
                break;
            case "show":
                showOnePatient(req, resp);
                break;

        }
    }

    protected void showAllPatients(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException{
        req.setAttribute("patients", patientService.getAllPatients());
        req.getRequestDispatcher("/WEB-INF/patients/list.jsp").forward(req, resp);
    }

    protected void add(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException{
        String firstName =  req.getParameter("firstName");
        String lastName = req.getParameter("lastName");
        LocalDate dob = LocalDate.parse(req.getParameter("dob"));

        String uploadPath = getServletContext().getRealPath("/images");

        File file = new File(uploadPath);
        if(!file.exists()){
            file.mkdirs();
        }

        Part image = req.getPart("image");

        String imageURL = image.getSubmittedFileName();

        image.write(uploadPath+File.separator+imageURL);

        //String imageURL = "tata";
        Patient patient = new Patient(firstName,lastName, imageURL, dob);
        patientService.addPatient(patient);
        System.out.println("Patient ajouté : "+patient);
        resp.sendRedirect("list");
    }

    protected void showOnePatient(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException{
        req.setAttribute("p", patientService.getPatientById(Integer.parseInt(req.getParameter("id"))));
        req.getRequestDispatcher("/WEB-INF/patients/show.jsp").forward(req, resp);
    }
}
