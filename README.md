UCP 1
<img width="864" height="540" alt="image" src="https://github.com/user-attachments/assets/61e0b638-3107-4600-b180-187e388fa967" />
<img width="864" height="540" alt="image" src="https://github.com/user-attachments/assets/dd4527ba-0b9c-429e-be7c-aa617c87311f" />

Perbaikan sql ucp 1
<img width="1920" height="1200" alt="Screenshot 2026-05-13 181355" src="https://github.com/user-attachments/assets/2be56966-fc9c-47bc-bf6f-30ca8262c387" />
<img width="1920" height="1200" alt="Screenshot 2026-05-13 181410" src="https://github.com/user-attachments/assets/ed5732e6-90f4-412e-9011-3aebdf5f58a8" />
<img width="1920" height="1200" alt="Screenshot 2026-05-13 181421" src="https://github.com/user-attachments/assets/3d7ed1d9-50e2-49d9-8815-f6512bf8e49d" />
<img width="1920" height="1200" alt="Screenshot 2026-05-13 181341" src="https://github.com/user-attachments/assets/769eab4b-eb4c-4057-b596-5feb6045c293" />
<img width="1920" height="1200" alt="Screenshot 2026-05-13 181431" src="https://github.com/user-attachments/assets/4fd7cd35-a7a4-425e-853a-46426b15e7e9" />
<img width="1920" height="1200" alt="Screenshot 2026-05-13 181442" src="https://github.com/user-attachments/assets/1649cf82-5d89-471e-b063-a3409706dd30" />
<img width="1920" height="1200" alt="Screenshot 2026-05-13 181455" src="https://github.com/user-attachments/assets/b9e4192f-2802-4cba-bab1-c5023aaf3a1f" />
<img width="1920" height="1200" alt="Screenshot 2026-05-13 181507" src="https://github.com/user-attachments/assets/43fd6e26-c3a4-49e5-a6a5-01b0e9b47fe5" />
<img width="1920" height="1200" alt="Screenshot 2026-05-13 181530" src="https://github.com/user-attachments/assets/506dc690-3571-4107-bf02-fad41c9606f6" />
<img width="1920" height="1200" alt="Screenshot 2026-05-13 181539" src="https://github.com/user-attachments/assets/dff53647-0f06-4dc4-a526-67f9b2a6bd25" />


UCP 2

Pada proyek ini, saya mensimulasikan celah keamanan SQL Injection pada Form Dashboard (Form 2). Celah ini terjadi karena input dari user pada fitur pencarian langsung digabungkan ke dalam string query SQL tanpa melalui proses parameterisasi. Query rentan (raw string) yang digunakan adalah:

UPDATE Sayur SET NamaSayur = 'HACKED' WHERE NamaSayur = '' OR 1=1 --'

Input ' OR 1=1 -- membuat kondisi pencarian pada perintah WHERE selalu bernilai TRUE. Akibatnya, perintah yang seharusnya hanya mengubah satu data sayur justru akan mengubah seluruh isi tabel secara massal menjadi tulisan "HACKED". Hal ini menunjukkan betapa bahayanya jika input pengguna tidak dibatasi, karena penyerang dapat memanipulasi seluruh integritas data dalam database.

Contoh
Seorang pengguna mencoba merusak integritas data inventaris dengan mengubah semua nama produk menjadi pesan tertentu. Payload yang Digunakan: ' OR 1=1 --

Langkah-langkah:
Buka Form 2 (Dashboard) dan pilih menu Sayur dan Harga.
Pada kolom Cari Sayur, masukkan input: ' OR 1=1 --
Tekan tombol Test Injection.
Hasil akan terlihat: seluruh nama sayur di dalam tabel telah terinjeksi dan berubah menjadi tulisan "HACKED".
