import { View, Text, FlatList, StyleSheet } from 'react-native'
import React from 'react'
import ContactItem from './ContactItem.jsx'

export default function ContactList() {

    const contacts = [
        {id:1, name:"Toto", phone:"+330123456", email:"toto@tata.fr"},
        {id:2, name:"Tata", phone:"+330123445", email:"Tata@tata.fr"},
        {id:3, name:"Titi", phone:"+331223454", email:"Titi@tata.fr"},
        {id:4, name:"Tutu", phone:"+335223445", email:"Tutu@tata.fr"},
        {id:5, name:"Totu", phone:"+334563457", email:"Totu@tata.fr"},
        {id:6, name:"Tato", phone:"+337895458", email:"Tato@tata.fr"},
        {id:7, name:"Tati", phone:"+337865259", email:"Tati@tata.fr"},
        {id:8, name:"Toto", phone:"+330123456", email:"toto@tata.fr"},
        {id:9, name:"Tata", phone:"+330123445", email:"Tata@tata.fr"},
        {id:10, name:"Titi", phone:"+331223454", email:"Titi@tata.fr"},
        {id:11, name:"Tutu", phone:"+335223445", email:"Tutu@tata.fr"},
        {id:12, name:"Totu", phone:"+334563457", email:"Totu@tata.fr"},
        {id:13, name:"Tato", phone:"+337895458", email:"Tato@tata.fr"},
        {id:14, name:"Tati", phone:"+337865259", email:"Tati@tata.fr"},
    ]

  return (
    <View style={styles.list}>
        <Text style={styles.title}>Liste des contacts :</Text>
        <FlatList
            data={contacts}
            keyExtractor={(item) => item.id}
            renderItem={({item}) => (
                <ContactItem contact={item}/>
            )}
        />
    </View>
  )
}

const styles = StyleSheet.create({
    list:{
        marginTop:10,
        padding:40,
        gap:30
    },
    title:{
        fontSize:30
    }
})