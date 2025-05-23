import { initializeApp } from 'firebase/app';
import { getAnalytics, isSupported } from 'firebase/analytics';

const firebaseConfig = {
  apiKey: "AIzaSyAIiNbBbfJiXnz9jnfZ5r4wEy82mpRNoe4",
  authDomain: "coininsightweb.firebaseapp.com",
  projectId: "coininsightweb",
  storageBucket: "coininsightweb.firebasestorage.app",
  messagingSenderId: "366461276697",
  appId: "1:366461276697:web:44d7c88a2f073d191f5088",
  measurementId: "G-29KZKSKNLM"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);

// Initialize Analytics and export it
export const analytics = typeof window !== 'undefined' 
  ? isSupported().then(yes => yes ? getAnalytics(app) : null) 
  : null;

export default app; 