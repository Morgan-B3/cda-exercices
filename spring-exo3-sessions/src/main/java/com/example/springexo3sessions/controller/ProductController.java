package com.example.springexo3sessions.controller;

import com.example.springexo3sessions.model.Product;
import com.example.springexo3sessions.service.ProductService;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/api/products")
public class ProductController {
    private ProductService productService;

    public ProductController(ProductService productService) {
        this.productService = productService;
    }

    @GetMapping
    public Map<String, List<Product>> getProducts(){
        return productService.getProducts();
    }

    @PostMapping
    public String addProduct(@RequestBody Product product){
        return productService.addProduct(product);
    }

    @DeleteMapping("/{id}")
    public String deleteProduct(@PathVariable String id){
        return productService.deleteProduct(id);
    }

    @PutMapping("/{id}")
    public String updateProduct(@PathVariable String id, @RequestBody Product product){
        return productService.updateProduct(id, product);
    }
}
