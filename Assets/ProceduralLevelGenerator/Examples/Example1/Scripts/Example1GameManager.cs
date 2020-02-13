﻿using System.Collections;
using System.Diagnostics;
using Assets.ProceduralLevelGenerator.Examples.Common;
using Assets.ProceduralLevelGenerator.Scripts.Generators.DungeonGenerator;
using UnityEngine;

namespace Assets.ProceduralLevelGenerator.Examples.Example1.Scripts
{
    public class Example1GameManager : GameManagerBase<Example1GameManager>
    {
        public void Update()
        {
            if (Input.GetKey(KeyCode.G))
            {
                LoadNextLevel();
            }
        }

        public override void LoadNextLevel()
        {
            // Show loading screen
            ShowLoadingScreen("Example 1", "loading..");

            // Find the generator runner
            var generator = GameObject.Find("Dungeon Generator").GetComponent<DungeonGeneratorRunner>();

            // Start the generator coroutine
            StartCoroutine(GeneratorCoroutine(generator));
        }

        /// <summary>
        /// Coroutine that generates the level.
        /// We need to yield return before the generator starts because we want to show the loading screen
        /// and it cannot happen in the same frame.
        /// It is also sometimes useful to yield return before we hide the loading screen to make sure that
        /// all the scripts that were possibly created during the process are properly initialized.
        /// </summary>
        private IEnumerator GeneratorCoroutine(DungeonGeneratorRunner generator)
        {
            yield return null;

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            generator.Generate();

            stopwatch.Stop();

            yield return null;

            SetLevelInfo($"Generated in {stopwatch.ElapsedMilliseconds/1000d:F}s");
            HideLoadingScreen();
        }
    }
}