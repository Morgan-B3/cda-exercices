import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import Contact from './components/exo1/Contact.jsx';

export default function App() {
  return (
    <View style={styles.container}>
      <StatusBar style="auto" />
      <Contact name="Toto" phone="012345678" email="toto@tata.com"/>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
