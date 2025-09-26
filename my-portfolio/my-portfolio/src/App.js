import WelcomeSection from './components/WelcomeSection';
import Navbar from './components/Navbar';
import About from './components/About';
import './App.css';
import ProjectsAndSkillsSection from './components/Projects/projects';
import Footer from './components/Footer/footer';
import { Route, Routes } from 'react-router-dom';
import { Outlet } from 'react-router-dom';
import PrivacyPolicy from './components/Privacy/privacy';
import UseOfTerm from './components/UseOfTerm/use_of_term';

function MainLayout() {
  return (
    <div>
      <Navbar />
      <main>
        <Outlet />
      </main>
      <Footer />
    </div>
  );
}

function MinimalLayout() {
  return (
    <div>
      <main>
        <Outlet />
      </main>
    </div>
  );
}

function App() {
  return (
    <Routes>
      <Route element={<MainLayout />}>
        <Route path="/" element={<WelcomeSection />} />
        <Route path="about" element={<About />} />
        <Route path="projects" element={<ProjectsAndSkillsSection />} />
      </Route>
      
      <Route element={<MinimalLayout />}>
        <Route path="privacy" element={<PrivacyPolicy />} />
        <Route path="Use Of Term" element={<UseOfTerm />} />
      </Route>
    </Routes>
  );
}

export default App;
