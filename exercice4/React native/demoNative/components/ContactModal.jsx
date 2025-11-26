import { View, Text, Modal, Pressable, StyleSheet, Linking, Alert } from 'react-native'
import React from 'react'

export default function ContactModal({contact, visible, setVisible}) {
    async function makeCall(){
        const possible = await Linking.canOpenURL('tel:'+contact.phone)
        if(possible){
            await Linking.openURL('tel:'+contact.phone)
        } else {
            Alert.alert("Action impossible")
        }
    }

    async function sendMail(){
        const possible = await Linking.canOpenURL('mailto:'+contact.email)
        if(possible){
            await Linking.openURL('mailto:'+contact.email)
        } else {
            Alert.alert("Adresse mail invalide")
        }
    }

  return (
    <Modal visible={visible} onRequestClose={()=>setVisible(false)} >
        <View style={styles.betweenCol}>
            <View style={styles.container}>
                <View style={styles.profile}>
                    <Text style={styles.title}>👤</Text>
                    <Text style={styles.title}>{contact.name}</Text>
                </View>
                <View style={styles.between}>
                    <Text style={styles.text}>📞 Téléphone :</Text>
                    <Pressable onPress={()=>makeCall()}>
                        <Text style={styles.action}>{contact.phone}</Text>
                    </Pressable>
                </View>
                <View style={styles.between}>
                    <Text style={styles.text}>📧 Email :</Text>
                    <Pressable onPress={()=>sendMail()}>
                        <Text style={styles.action}>{contact.email}</Text>
                    </Pressable>
                </View>
            </View>
            <Pressable>
                <Text style={styles.button}>✆ Appeler</Text>
            </Pressable>
            <Pressable onPress={()=>setVisible(false)}>
                <Text style={{fontSize:20}}>◀Retour</Text>
            </Pressable>
        </View>
    </Modal>
  )
}

const styles = StyleSheet.create({
    container:{
        gap:20
    },
    profile:{
        justifyContent:"center",
        alignItems:"center"
    },
    title:{
        fontSize:40
    },
    text:{
        fontSize:20
    },
    between:{
        flexDirection:"row",
        justifyContent:'space-between'
    },
    betweenCol:{
        flex:1,
        justifyContent:"space-between",
        padding:30,
    },
    action:{
        fontSize:20,
        color:"blue",
        textDecorationLine:"underline"
    },
    button:{
        fontSize:30,
        margin:"auto",
        backgroundColor:"#32b826ff",
        paddingHorizontal:20,
        paddingVertical:10,
        borderRadius:50,
        fontWeight:"bold",
        color:"white"
    }
})