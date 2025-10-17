import { View, Text, StyleSheet } from 'react-native'
import { createNativeStackNavigator } from '@react-navigation/native-stack'
import { NavigationContainer } from '@react-navigation/native'
import React from 'react'
import ContactList from './components/ContactList.jsx'
import ContactDetail from './components/ContactDetail.jsx'
import ContactNew from './components/ContactNew.jsx'

const Stack = createNativeStackNavigator()


export default function AppNavigation() {
  return (
    <NavigationContainer>
        <Stack.Navigator initialRouteName="ContactsList">
            <Stack.Screen name="ContactsList" component={ContactList} options={{title:"Mes contacts"}}/>
            <Stack.Screen name="Contact" component={ContactDetail}/>
            <Stack.Screen name="ContactNew" component={ContactNew} options={{title:"Ajouter un contact"}}/>
        </Stack.Navigator>
    </NavigationContainer>
  )
}

const styles = StyleSheet.create({
    app:{
        backgroundColor:"#2e2e2eff"
    }
})