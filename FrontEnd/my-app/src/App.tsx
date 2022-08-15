import axios from "axios";
import { useState } from 'react';
import './App.css';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import SearchIcon from '@mui/icons-material/Search';
import Divider from '@mui/material/Divider';

function App() {

  const [songTitle, setSongTitle] = useState("");
  const [songArtist, setSongArtist] = useState("");
  const [songLyrics, setLyrics] = useState<undefined | { lyrics: "" }>(undefined);


  const LYRIC_BASE_URL = "https://api.lyrics.ovh/v1";

  return (
    <div>
      <h1 style={{ display: "flex", justifyContent: "center" }}>
        Find Lyrics
      </h1>

      <div style={{ display: "flex", justifyContent: "center", gap: 10}}>
      <TextField
          id="search-bar"
          className="text"
          value={songTitle}
          onChange={(prop: any) => {
            setSongTitle(prop.target.value);
          }}
          label="Enter Title"
          variant="outlined"
          placeholder="Search..."
          size="small"
        />
      
      <TextField
          id="search-bar"
          className="text"
          value={songArtist}
          onChange={(prop: any) => {
            setSongArtist(prop.target.value);
          }}
          label="Enter Artist"
          variant="outlined"
          placeholder="Search..."
          size="small"
        />
        <br />
        
        <Button
        onClick={() => {
          search();
        }} 
        variant="outlined" 
        startIcon={<SearchIcon />}>
        Search
      </Button>
     
      </div>
      
      <Divider>~~~~~</Divider>
      <div style={{ display: "flex", justifyContent: "center"}} id="result"></div>

    </div>


  );

  function search() {
    axios
      .get(LYRIC_BASE_URL + "/" + songArtist + "/" + songTitle)
      .then((res) => {
        setLyrics(res.data);
      })
      .catch((err) => {
        console.log("Lyric not found");
        setLyrics(undefined);
      });

    songLyrics === undefined ? (
      document.getElementById("result")!.innerHTML = "No Song Found. You have entered| Artist: " + songArtist + " | Title: " + songTitle

    ) : (
      document.getElementById("result")!.innerHTML = JSON.stringify(songLyrics.lyrics).replaceAll("\\n", "<br>").replaceAll("\\r", "<br>")
    )
  }
}

export default App;
