package com.example.springexo2.controller;

import com.example.springexo2.dto.DirectorGetDto;
import com.example.springexo2.entity.Director;
import com.example.springexo2.service.DirectorService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("catalogue/realisateurs")
public class DirectorController {
    private DirectorService directorService;
    public DirectorController(DirectorService directorService){
        this.directorService = directorService;
    }

    @GetMapping
    public ResponseEntity<List<Director>> findAll(){
        return ResponseEntity.ok(directorService.findAll());
    }

    @GetMapping("/{id}")
    public ResponseEntity<Director> findById(@PathVariable long id){
        return ResponseEntity.ok(directorService.findById(id));
    }

    @PostMapping
    public ResponseEntity<Director> save(@RequestBody DirectorGetDto directorGetDto){
        System.out.println(directorGetDto);
        return ResponseEntity.ok(directorService.create(directorGetDto));
    }

    @PutMapping("/{id}")
    public ResponseEntity<Director> update(@PathVariable long id, @RequestBody DirectorGetDto directorGetDto){
        return ResponseEntity.ok(directorService.update(id, directorGetDto));
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<String> delete(@PathVariable long id){
        return ResponseEntity.ok(directorService.delete(id));
    }

}
