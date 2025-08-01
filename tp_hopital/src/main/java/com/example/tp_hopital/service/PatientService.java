package com.example.tp_hopital.service;

import com.example.tp_hopital.model.Patient;
import com.example.tp_hopital.repository.PatientRepository;
import org.hibernate.Session;
import org.hibernate.SessionFactory;

import java.util.ArrayList;
import java.util.List;

public class PatientService implements IPatientService {
    private Session session;
    private SessionFactory sessionFactory;
    private PatientRepository patientRepository;

    public PatientService(SessionFactory sessionFactory){
        this.sessionFactory = sessionFactory;
    }

    @Override
    public List<Patient> getAllPatients() {
        List<Patient> patients = new ArrayList<>();
        session = sessionFactory.openSession();
        patientRepository = new PatientRepository(session);
        try {
            patients = patientRepository.findAll();
        }catch (Exception e){
            e.printStackTrace();
        }finally {
            session.close();
        }
        return patients;
    }

    @Override
    public void addPatient(Patient patient) {
        session = sessionFactory.openSession();
        session.beginTransaction();
        patientRepository = new PatientRepository(session);
        try{
            patientRepository.create(patient);
            session.getTransaction().commit();
        }catch (Exception e){
            try {
                session.getTransaction().rollback();
            }catch (Exception e1){
                e1.printStackTrace();
            }
        }finally {
            session.close();
        }
    }

    @Override
    public Patient getPatientById(int id) {
        Patient patient = null;
        session = sessionFactory.openSession();
        patientRepository = new PatientRepository(session);
        try{
            patient = patientRepository.findById(id);
        }catch (Exception e){
            e.printStackTrace();
        }finally {
            session.close();
        }
        return patient;
    }
}
