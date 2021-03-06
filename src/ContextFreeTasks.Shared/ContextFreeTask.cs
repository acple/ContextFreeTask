﻿using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ContextFreeTasks.Internal;
using static System.Threading.Tasks.Task;

namespace ContextFreeTasks
{
    [AsyncMethodBuilder(typeof(AsyncContextFreeTaskMethodBuilder))]
    public struct ContextFreeTask
    {
        private readonly Task _task;
        public Task Task => _task ?? FromResult(default(object));
        internal ContextFreeTask(Task t) => _task = t;
        public ContextFreeTaskAwaiter GetAwaiter() => new ContextFreeTaskAwaiter(Task);
        public void Wait() => _task?.Wait();
        public ConfiguredTaskAwaitable ConfigureAwait(bool continueOnCapturedContext) => Task.ConfigureAwait(continueOnCapturedContext);
    }
}
