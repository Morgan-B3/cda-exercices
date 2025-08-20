package com.example.springexo4pagination.controller;

import com.example.springexo4pagination.model.Creature;
import com.example.springexo4pagination.service.CreatureService;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Sort;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("api/creatures")
public class CreatureController {
    private CreatureService creatureService;

    public CreatureController(CreatureService creatureService){
        this.creatureService = creatureService;
    }

    @GetMapping
    public ResponseEntity<List<Creature>> getAll(){
        System.out.println("getAll");
        return ResponseEntity.ok(creatureService.findAll());
    }

    @GetMapping("/{id}")
    public ResponseEntity<Creature> getOne(@PathVariable Long id){
        return ResponseEntity.ok(creatureService.findById(id));
    }

    @GetMapping("/paged")
    public Page<Creature> getPage(@RequestParam(defaultValue = "0") int page, @RequestParam(defaultValue = "5")  int size){
        return creatureService.getPage(PageRequest.of(page,size));
    }

    @PostMapping
    public ResponseEntity<String> create(@RequestBody Creature creature){
        return ResponseEntity.status(HttpStatus.CREATED).body(creatureService.save(creature));
    }

    @PutMapping("/{id}")
    public ResponseEntity<String> update(@RequestBody Creature creature,  @PathVariable Long id){
        return ResponseEntity.ok(creatureService.update(id, creature));
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<String> delete(@PathVariable Long id){
        return ResponseEntity.ok(creatureService.delete(id));
    }

    @GetMapping("/sorted")
    public Page<Creature> getSorted(@RequestParam(defaultValue = "0") int page, @RequestParam(defaultValue = "20")  int size, @RequestParam(defaultValue = "weight") String sortField, @RequestParam(defaultValue = "ASC") String direction){
        return creatureService.getPage(PageRequest.of(page,size).withSort(Sort.Direction.valueOf(direction),sortField));
    }
}
