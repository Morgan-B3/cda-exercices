package com.example.springexo4pagination.service;

import com.example.springexo4pagination.model.Creature;
import com.example.springexo4pagination.repository.CreatureRepository;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CreatureService {
    private CreatureRepository creatureRepository;
    public CreatureService(CreatureRepository creatureRepository) {
        this.creatureRepository = creatureRepository;
    }

    public List<Creature> findAll() {
        return creatureRepository.findAll();
    }

    public Creature findById(Long id) {
        return creatureRepository.findById(id).orElse(null);
    }

    public String save(Creature creature) {
        creatureRepository.save(creature);
        return "Creature enregistrée";
    }

    public String delete(Long id) {
        creatureRepository.deleteById(id);
        return "Créature supprimée";
    }

    public String update(Long id, Creature creature) {
        Creature updatedCreature = creatureRepository.findById(id).orElseThrow(EntityNotFoundException::new);
        updatedCreature.setName(creature.getName());
        updatedCreature.setAge(creature.getAge());
        updatedCreature.setWeight(creature.getWeight());
        updatedCreature.setDangerous(creature.isDangerous());
        updatedCreature.setType(creature.getType());
        creatureRepository.save(updatedCreature);
        return "Creature mise à jour";
    }

    public Page<Creature> getPage(Pageable pageable){
        return creatureRepository.findAll(pageable);
    }
}
