import { View, Text, StyleSheet, Pressable } from 'react-native'
import React, { useState } from 'react'
import ContactModal from './ContactModal.jsx'

export default function ContactItem({contact}) {

    const[visible, setVisible] = useState(false)

  return (
    <View>
        <Pressable style={styles.container} onPress={()=>setVisible(true)}>
            <Text style={styles.text}>{contact.name}</Text>
        </Pressable>

        <ContactModal contact={contact} visible={visible} setVisible={setVisible}/>

    </View>
  )
}

const styles = StyleSheet.create({
    container:{
        marginBottom:20,
        backgroundColor: "#eff1f1ff",
        padding:10,
        borderRadius:10
    },
    text:{
        fontSize:20
    }
})