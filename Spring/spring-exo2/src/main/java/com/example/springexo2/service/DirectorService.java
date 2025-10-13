package com.example.springexo2.service;

import com.example.springexo2.dto.DirectorGetDto;
import com.example.springexo2.entity.Director;
import com.example.springexo2.repository.DirectorRepository;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class DirectorService {
    private DirectorRepository directorRepository;
    public DirectorService(DirectorRepository directorRepository) {
        this.directorRepository = directorRepository;
    }

    public List<Director> findAll(){
        return directorRepository.findAll();
    }

    public Director findById(long id){
        return directorRepository.findById(id).orElseThrow(EntityNotFoundException::new);
    }

    public Director create(DirectorGetDto directorGetDto){
        return directorRepository.save(directorGetDto.dtoToEntity());
    }

    public Director update(long id, DirectorGetDto directorGetDto){
        Director updatedDirector = directorRepository.findById(id).orElseThrow(EntityNotFoundException::new);
        Director incomingDirector = directorGetDto.dtoToEntity();
        updatedDirector.setId(incomingDirector.getId());
        updatedDirector.setFirstName(incomingDirector.getFirstName());
        updatedDirector.setLastName(incomingDirector.getLastName());
        updatedDirector.setCountry(incomingDirector.getCountry());
        return directorRepository.save(updatedDirector);
    }

    public String delete(Long id){
        directorRepository.deleteById(id);
        return "Réalisateur supprimé";
    }
}
