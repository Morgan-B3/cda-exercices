package com.example.springexo3sessions.service;

import com.example.springexo3sessions.model.Product;
import jakarta.servlet.http.HttpSession;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.RequestBody;

import java.util.*;

@Service
public class ProductService {
    private HttpSession session;
    public ProductService(HttpSession session){
        this.session=session;
    }

    public Map<String, List<Product>> getProducts(){
        return (Map<String, List<Product>>) session.getAttribute("products");
    }

    public String addProduct(Product product){
        Map<String,List<Product>> products= (Map<String, List<Product>>) session.getAttribute("products");
        List<Product> productList = new ArrayList<>();
        if (products == null) {
            products = new HashMap<>();
        }
        if (products.containsKey(product.getId())) {
            productList=products.get(product.getId());
        }
        productList.add(product);
        products.put(product.getId(),productList);
        session.setAttribute("products",products);
        return "Produit ajouté";
    }

    public String deleteProduct(String id){
        Map<String,List<Product>> products= (Map<String, List<Product>>) session.getAttribute("products");
        String message="";
        if (products!=null && products.get(id)!=null ){
            products.get(id).remove(0);
            if(products.get(id).isEmpty() ){
                products.remove(id);
            }
            message = "Produit supprimé";
        } else {
            message = "Le produit n'est pas dans le panier";
        }
        session.setAttribute("products",products);
        return message;
    }

    public String updateProduct(String id,Product product){
        Map<String,List<Product>> products= (Map<String, List<Product>>) session.getAttribute("products");
        List<Product> productList = new ArrayList<>();
        String message="";
        if (products!=null && products.get(id)!=null ){
            if (!product.getId().equals(id) && products.containsKey(product.getId())){
                message = "Cet id est déjà utilisé";
                return message;
            } else {
                productList=products.get(id);
                for (Product p : productList){
                    p.setId(product.getId());
                    p.setName(product.getName());
                    p.setPrice(product.getPrice());
                }
                if(!product.getId().equals(id)){
                    products.remove(id);
                }
            }
            products.put(product.getId(),productList);
            message = "Produit modifié";
        } else {
            message = "Le produit n'est pas dans le panier";
        }
        session.setAttribute("products",products);
        return message;
    }

//    public String validate(){
//        Map<String,List<Product>> products= (Map<String, List<Product>>) session.getAttribute("products");
//
//    }
}
