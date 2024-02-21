using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace V3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Node head = null;
        private Node currentSong;
        private Node tail;
        private WaveOutEvent waveOut;
        private AudioFileReader audioFile;
        private Timer trackBarUpdateTimer;
        private bool isPaused;

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_SongName.Text = "Please Add Music";
            lbl_CurrentPosition.Text = "00:00";
            lbl_TotalDuration.Text = "00:00";
        } 
        class Node
        {
            public String name;
            public String path;
            public Node prev;
            public Node next;
        }

        private void btn_Add_Click(object sender, EventArgs e)              // Add Music
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    string fileName = Path.GetFileName(filePath);

                    InsertAtEnd(fileName, filePath);
                    songList.Items.Add(fileName);
                }
            }
        }
        private void btn_AddQueue_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string currentlyPlayingSong = songList.SelectedItem?.ToString();

                if (currentlyPlayingSong != null)
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        string fileName = Path.GetFileName(filePath);
                        songList.Items.Insert(songList.SelectedIndex + 1, fileName);

                        InsertAfter(currentlyPlayingSong, fileName, filePath);
                    }
                }
            }
        }
        private void btn_Next_Click(object sender, EventArgs e)         // button Next
        {
            if (currentSong != null)
            {
                if (currentSong.next != null)
                {
                    currentSong = currentSong.next;
                }
                else
                {
                    currentSong = head;
                }

                PlaySelectedSong();
            }
        }
        private void btn_Previous_Click(object sender, EventArgs e)         // button Previous
        {
            if (currentSong != null)
            {
                if (currentSong.prev != null)
                {
                    currentSong = currentSong.prev;
                }
                else
                {
                    currentSong = GetLastNode();
                }

                PlaySelectedSong();
            }
        }
        private void btn_PlayPause_Click(object sender, EventArgs e)            // button play pause
        {
            if (currentSong != null)
            {
                if (waveOut == null)
                {
                    string path = currentSong.path;
                    waveOut = new WaveOutEvent();
                    audioFile = new AudioFileReader(path);
                    waveOut.Init(audioFile);
                    waveOut.Play();

                    btn_PlayPause.Text = "Pause";
                    StartTrackBarUpdateTimer();
                }
                else if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Pause();
                    btn_PlayPause.Text = "Play";
                }
                else if (waveOut.PlaybackState == PlaybackState.Paused)
                {
                    waveOut.Play();
                    btn_PlayPause.Text = "Pause";
                }
            }
        }
        private void btn_RemoveSong_Click(object sender, EventArgs e)           // button remove
        {
            if (songList.SelectedIndex >= 0)
            {
                string selectedSong = songList.SelectedItem.ToString();
                Node selectedNode = FindNodeByData(selectedSong);

                if (selectedNode != null)
                {
                    if (currentSong == selectedNode && waveOut != null)
                    {
                        StopPlayback();
                    }

                    if (selectedNode.prev != null)
                    {
                        selectedNode.prev.next = selectedNode.next;
                    }
                    else
                    {
                        head = selectedNode.next;
                    }

                    if (selectedNode.next != null)
                    {
                        selectedNode.next.prev = selectedNode.prev;
                    }

                    songList.Items.Remove(selectedSong);

                    if (currentSong == selectedNode)
                    {
                        currentSong = null;
                        UpdateCurrentSongDisplay();
                    }
                    lbl_CurrentPosition.Text = "00:00";
                    lbl_TotalDuration.Text = "00:00";
                    lbl_SongName.Text = "";
                }
            }

        }


        private void songList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (songList.SelectedIndex >= 0)
            {
                string selectedSong = songList.SelectedItem.ToString();
                currentSong = FindNodeByData(selectedSong);
                PlaySelectedSong();
            }
        }
        public void InsertAtEnd(string fileName, string filePath)
        {
            Node newNode = new Node();
            newNode.name = fileName;
            newNode.path = filePath;
            newNode.next = null;

            if (head == null)
            {
                newNode.prev = null;
                head = newNode;
                tail = newNode;
                return;
            }

            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }
        public void InsertAfter(string existingSong, String fileName, String filePath)
        {
            Node currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.name == existingSong)
                {
                    Node newNode = new Node();
                    newNode.name = fileName;
                    newNode.path = filePath;

                    newNode.next = currentNode.next;
                    if (currentNode.next != null)
                    {
                        currentNode.next.prev = newNode;
                    }
                    newNode.prev = currentNode;
                    currentNode.next = newNode;

                    break;
                }

                currentNode = currentNode.next;
            }
        }

        private Node FindNodeByData(string targetData)              // find node
        {
            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.name == targetData)
                {
                    return currentNode;
                }
                currentNode = currentNode.next;
            }
            return null;
        }
        private void UpdateCurrentSongDisplay()                     // update UI
        {
            if (currentSong != null)
            {
                lbl_SongName.Text = currentSong.name;

                int songIndex = songList.Items.IndexOf(currentSong.name);
                if (songIndex >= 0)
                {
                    songList.SelectedIndex = songIndex;
                }
            }
            else
            {
                lbl_SongName.Text = "No song selected";
                songList.SelectedIndex = -1;
            }
        }
        private void StartTrackBarUpdateTimer()
        {
            trackBarUpdateTimer = new Timer();
            trackBarUpdateTimer.Interval = 100;
            trackBarUpdateTimer.Tick += TrackBarUpdateTimer_Tick;
            trackBarUpdateTimer.Start();
        }
        private void TrackBarUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (waveOut != null && audioFile != null)
            {
                int currentPosition = (int)(audioFile.Position / (double)audioFile.Length * trackBar.Maximum);
                trackBar.Value = currentPosition;

                TimeSpan totalDuration = audioFile.TotalTime;
                TimeSpan currentDuration = TimeSpan.FromSeconds(currentPosition * totalDuration.TotalSeconds / trackBar.Maximum);
                lbl_CurrentPosition.Text = $"{currentDuration:mm\\:ss}";
                lbl_TotalDuration.Text = $"{totalDuration:mm\\:ss}";
            }
        }
        private void StopPlayback()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }

            trackBar.Value = 0;
        }
        private Node GetLastNode()
        {
            if (head == null)
            {
                return null;
            }

            Node currentNode = head;
            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
            }

            return currentNode;
        }
        private void PlaySelectedSong()
        {
            if (currentSong != null)
            {
                StopPlayback();

                string path = currentSong.path;
                waveOut = new WaveOutEvent();
                audioFile = new AudioFileReader(path);
                waveOut.Init(audioFile);
                waveOut.Play();

                UpdateCurrentSongDisplay();

                isPaused = false;

                StartTrackBarUpdateTimer();
            }
        }


    }
}
