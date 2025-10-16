import React from 'react'
import { View, Text, StyleSheet, Image } from 'react-native'

export default function Contact({name, phone, email}) {
  return (
    <View style={styles.view}>
        <Text style={styles.name}>{name}</Text>
        <Text style={styles.email}>{email}</Text>
        <Text style={styles.phone}>{phone}</Text>
    </View>
  )
}

const styles = StyleSheet.create({
    view:{
        backgroundColor:"#b3e0dfff",
        borderRadius:50,
        padding:50,
        alignItems:"center",
        gap:50
    },
    name: {
        color : '#23a8d1ff',
        fontSize : 40,
        fontWeight : '900'
    },
    phone: {
        color: '#00b4aeff',
        fontSize: 30
    },
    email: {
        width:'100%',
    }
})
