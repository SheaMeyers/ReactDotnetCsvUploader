import { useRef, useState } from 'react';
import './App.css';

const App = () => {
  const csvFileRef = useRef<HTMLInputElement>(null);
  const [feedback, setFeedback] = useState<string>('');

  const postCsvFile = async () => {
    if (csvFileRef.current === null || csvFileRef.current.files === null) return
  
    const formData = new FormData();
    formData.append("csvFile", csvFileRef.current.files[0]);
    const response = await fetch('/Upload/User', { method: "POST", body: formData });
    csvFileRef.current.value = ''
    const feedbackMessage = response.ok ? 'Success' : 'Failure'
    setFeedback(feedbackMessage)
    setTimeout(() => setFeedback(''), 5000)
  }
  
  return (
    <div className="App">
      <header className="App-header">
        {feedback && <p>{feedback}</p>}
        <input type="file" id="csvFile" name="csvFile" accept=".csv" ref={csvFileRef}/> 
        <button onClick={postCsvFile}>Post Csv</button>
      </header>
    </div>
  );
}

export default App;
