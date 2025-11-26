import { View, Text, FlatList, StyleSheet, Pressable } from 'react-native'
import React from 'react'
import ContactItem from './ContactItem.jsx'

export default function ContactList({navigation}) {

    const goToContact = (contact)=>{
        navigation.navigate("Contact", contact)
    }

    const goToContactNew = ()=>{
        navigation.navigate("ContactNew")
    }

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
    <View style={styles.container}>
          <Pressable onPress={()=>goToContactNew()} style={styles.buttonContainer} >
            <Text style={styles.button}>+</Text>
        </Pressable>
        <View style={styles.list}>
            <FlatList
                data={contacts}
                keyExtractor={(item) => item.id}
                renderItem={({item}) => (
                    <ContactItem contact={item} navigate={goToContact}/>
                )}
                />
        </View>
       
    </View>
  )
}

const styles = StyleSheet.create({
    container:{
        flex:1,
        position:"relative"
    },
    list:{
        padding:20,
        gap:30,
        marginBottom:50,
        // backgroundColor:"#2e2e2eff"
    },
    title:{
        fontSize:30
    },
    buttonContainer:{
        position:"absolute",
        top:20,
        right:20,
        margin:"auto",
        margin:"auto",
        backgroundColor:"#32b826ff",
        paddingHorizontal:20,
        paddingVertical:10,
        borderRadius:100,
        width:60,
        height:60,
        zIndex:1
    },
    button:{
        fontSize:30,
        fontWeight:"bold",
        textAlign:"center",
        color:"white"
    }
})