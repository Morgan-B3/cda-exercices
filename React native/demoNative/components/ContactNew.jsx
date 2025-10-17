import { View, Text, Alert, Pressable, Button, TextInput, StyleSheet } from 'react-native'
import React, { useState } from 'react'

export default function ContactNew({navigation}) {

    const [name, setName] = useState("")
    const [phone, setPhone] = useState("")
    const [email, setEmail] = useState("")

    const namevalid = name.trim().length >= 3

    function submitForm() {
        Alert.alert("Formulaire",`Nom : ${name} | Téléphone : ${phone} | Email : ${email}`)
        setName('')
        setPhone('')
        setEmail('')
    }


  return (
    <View style={styles.container}>
        <View >
            <Text>Nom</Text>
            <TextInput 
                style ={styles.input}
                value={name}
                onChangeText={setName}
                placeholder='Toto'
                autoCapitalize='words'
            />
            {!namevalid && <Text>3 caracteres minimum</Text>}
        </View>
        <View >
            <Text>Numero de téléphone</Text>
            <TextInput 
                style ={styles.input}
                value={phone}
                onChangeText={setPhone}
                placeholder='012346789'
                autoCapitalize='none'
                keyboardType='phone-pad'
            />
        </View>
        <View >
            <Text>Adresse email</Text>
            <TextInput 
                style ={styles.input}
                value={email}
                onChangeText={setEmail}
                placeholder='toto@tata.fr'
                autoCapitalize='none'
                keyboardType="email-address"
            />
        </View>
        <Button title='valider' onPress={submitForm} disabled={!namevalid}/>
    </View>
  )
}

const styles = StyleSheet.create({
    container : {
        flex: 1,
        padding: 30,
        gap:30
    },
    input: {
        borderWidth: 1,
        borderColor : '#a5a5a5ff',
        borderRadius: 8,
        fontSize: 16
    }
})