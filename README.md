# Calculator

Simple four-function calculator Windows Forms application (C#, .NET Framework 4.7.2).

## Features
- Basic arithmetic: +, -, *, /
- Instant preview of the result while typing
- Buttons for digits, dot, π and e
- History panel that accumulates calculated results
- Click the result label to copy the displayed result to the clipboard

## Requirements
- Visual Studio 2022 (or newer) with .NET desktop development workload
- .NET Framework 4.7.2

## Build & Run
1. Open the solution in Visual Studio.
2. In __Solution Explorer__ select the project and open __Project > Properties__ to confirm the Target Framework is `.NET Framework 4.7.2`.
3. Press __F5__ or use __Debug > Start Debugging__ to build and run.

You can also build from the command line with MSBuild:
msbuild YourSolution.sln /p:Configuration=Release

## Usage
- Type an expression into the input box or use the on‑screen buttons.
- The preview result appears in the result label while you type.
- Press `=` (Calculate) to append the evaluated expression to the history area.
- Click the result label to copy the "expression = result" text to the clipboard.

Notes:
- The calculator accepts `π` and `e` symbols (buttons are provided).
- Consecutive operators are normalized (typing `1++2` will treat it sensibly).

## Setting or changing the application icon
Two options:

A. Use project resources (recommended)
1. Open __Project > Properties__ and go to the __Resources__ tab.
2. Use __Add Resource > Add Existing File...__ and add an `.ico` file (name it e.g. `AppIcon`).
3. In the form constructor (after `InitializeComponent()`), the project sets the icon from resources:
   this.Icon = Properties.Resources.AppIcon;

B. Use the Designer
1. Open the form in the __Form Designer__.
2. Select the form, open the __Properties Window__ and set the __Icon__ property (browse to an `.ico` file).
3. Save — the Designer will update `Form1.Designer.cs`.

Rebuild the project after changing resources so `Resources.Designer` is regenerated.

## Tests & Threading
- All UI updates happen on the UI thread. If you call calculator methods from background threads, marshal calls to the UI thread with `Invoke` / `BeginInvoke`.

## Contributing
- Open a PR with clear description and small focused changes.
- Keep UI changes in the Designer and logic in small helper classes.

## 🚀 About Me

*   **Interests:** Software Engineering and Collaborative Projects.
*   **Current Focus:** Sharpening my skills in **C++ and C#**.
*   **Goal:** To contribute to innovative and impactful development projects while collaborating with other skilled professionals.

### Continuous Learning
I am constantly expanding my knowledge in modern web development frameworks, tools, and best practices to stay at the forefront of technology.

## ✨ Portfolio

**My personal website**  
I'd love to hear from you! Whether you have a question, a project idea, or just want to chat about programming, tech, and development, feel free to send me a message.

**Portfolio URL:**  
`https://belalamrmohamed.github.io/portfolio/`

## 🌐 Onion Service (Tor Network)

**Note for Technical Users:**  
My portfolio is accessible as an **onion service** on the Tor network. It is hosted locally on my machine, so availability depends on my laptop being online and acting as a server.

**Onion URL:**  
`http://4zwkrzxvxxad7tv77qtobt6vx5nothdzv2t5ysisjefok2rl5i5te4yd.onion/`

## 🤝 Collaboration Opportunities

I am actively seeking opportunities to collaborate on exciting development projects! I'm open to:
*   Open-source contributions
*   Team-based development projects
*   Freelance work

I'm eager to apply my skills, learn from others, and help bring great ideas to life.

## 📫 Let's Connect!

Feel free to reach out for collaboration, project inquiries, or just to chat!

*   **Email:** [belalamrofficial@gmail.com](mailto:belalamrofficial@gmail.com)
*   **GitHub:** [@BelalAmrMohamed](https://github.com/BelalAmrMohamed)

---

### **Let's Build Something Amazing Together!**

I am passionate about creating impactful digital experiences and would love to be a part of your next project. Don't hesitate to get in touch!
